import { ref } from "vue";
import { useApi } from "@/composables/useApi";

export function useSuggestion() {
  const { get1, post1 } = useApi();

  const hasError1 = ref(false);
  const email = ref("");
  const asunto = ref("");
  const desc = ref("");
  const isSuggestion = ref(false);
  const sugg = ref('');

  const setSuggestion = async () => {
    hasError1.value = false;
    isSuggestion.value = false;
    const login = await post1("/api/Suggestions", { email: email.value, asunto: asunto.value, descripcion: desc.value });
    if (login.success) {
        isSuggestion.value = true;
    } else {
      hasError1.value = true;
    }
  };

  const getSuggestion = async () => {
    hasError1.value = false;
    isSuggestion.value = false;
    const login = await get1("/api/Suggestions");
    if (login.success) {
        sugg.value = login.data;
    } else {
      hasError1.value = true;
    }
  };

  return {
    setSuggestion,
    getSuggestion,
    hasError1,
    email,
    asunto,
    desc,
    isSuggestion,
    sugg
  };
}
