<template>
  <div class="fixed top-0 left-0 w-screen bg-purple-900">
    <header class="flex flex-col flex-nowrap">
      <div class="flex h-20 items-center">
		
        <div class="basis-1/6 m-5">
          <a href="#">
            <FakeIcon :width="150" :height="50" />
          </a>
        </div>

        <nav class="basis-1/2 flex items-center">
          <a href="#" class="flex tracking-widest uppercase text-base px-8"
            >
			<TrackIcon :height="20" :width="20" />Rastrear</a
          >
          <a href="#" class="flex tracking-widest uppercase text-base px-8"
            >
			<PackageIcon :height="20" :width="20" />Envíos</a
          >
          <a href="#" class="flex tracking-widest uppercase text-base px-8"
            >
			<LocationIcon :height="20" :width="20" />Sucursales</a
          >
          <a href="#" class="flex tracking-widest uppercase text-base px-8"
            >
			<ContactIcon :height="20" :width="20" />Contacto</a
          >
          <a href="#" class="flex tracking-widest uppercase text-base px-8">Admin</a>
        </nav>

        <div class="basis-1/4 m-5 flex items-center justify-end">
          <div class="basis-1/2 flex">
            <a href="#" class="text-xs">Registratse/Iniciar Sesión</a>
          </div>
          <div class="basis-1/6 flex">
            <a href="#"><UserIcon :height="40" :width="40" /></a>
          </div>
        </div>
      </div>
    </header>
  </div>
</template>

<script>
import FakeIcon from "@/components/icons/FakeDex.vue";
import UserIcon from "@/components/icons/User.vue";
import ContactIcon from "@/components/icons/Contact.vue";
import LocationIcon from "@/components/icons/Location.vue";
import PackageIcon from "@/components/icons/Package.vue";
import TrackIcon from "@/components/icons/Track.vue";
export default {
  name: "NavBar",
  components: {
    FakeIcon,
    UserIcon,
    ContactIcon,
    LocationIcon,
    PackageIcon,
    TrackIcon,
  },
};
</script>
