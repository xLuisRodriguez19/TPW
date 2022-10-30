<template>
  <div class="flex">
    <section class="bg-gray-50 p-10 rounded-lg shadow-lg">
      <div
        class="w-full bg-white rounded-lg shadow dark:border md:mt-0 sm:max-w-md xl:p-0"
      >
        <div class="p-6 space-y-4 md:space-y-6 sm:p-8">
          <h1
            class="text-xl font-bold leading-tight tracking-tight text-black md:text-2xl"
          >
            Inicio sesión en tu cuenta
          </h1>
          <form class="space-y-4 md:space-y-6" action="#">
            <div>
              <label
                for="email"
                class="block mb-2 text-sm font-medium text-black"
                >Correo</label
              >
              <input
                type="email"
                name="email"
                id="email"
                class="bg-gray-50 border border-gray-300 text-black sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5"
                placeholder="name@company.com"
                required=""
              />
            </div>
            <div>
              <label
                for="password"
                class="block mb-2 text-sm font-medium text-black"
                >Contraseña</label
              >
              <input
                type="password"
                name="password"
                id="password"
                placeholder="••••••••"
                class="bg-gray-50 border border-gray-300 text-black sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5"
                required=""
              />
            </div>
            <div class="flex items-center justify-between space-x-5">
              <div class="flex items-start">
                <div class="flex items-center h-5">
                  <input
                    id="remember"
                    aria-describedby="remember"
                    type="checkbox"
                    class="w-4 h-4 border border-gray-300 rounded bg-gray-50 focus:ring-3 focus:ring-primary-300"
                    required=""
                  />
                </div>
                <div class="ml-3 text-sm">
                  <label for="remember" class="text-purple-500"
                    >Recuerdame</label
                  >
                </div>
              </div>
              <a
                href="#"
                class="text-sm font-medium text-primary-600 hover:underline text-gray-500"
                >¿Olvidaste tu contraseña?'</a
              >
            </div>
            <button
              type="submit"
              class="w-full text-white bg-purple-500 hover:bg-purple-400 font-bold py-2 px-4 border-b-4 border-purple-700 hover:border-purple-500 rounded"
            >
              Entrar
            </button>
          </form>
        </div>
      </div>
    </section>

    <hr class="border-0 border-l-2 h-full w-0 shadow-lg">

    <section class="bg-gray-50 p-10 rounded-lg shadow-lg">
      <div
        class="w-full bg-white rounded-lg shadow dark:border md:mt-0 sm:max-w-md xl:p-0"
      >
        <div class="p-6 space-y-4 md:space-y-6 sm:p-8">
          <h1
            class="text-xl font-bold leading-tight tracking-tight text-black"
          >
            Inicia sesión como invitado
          </h1>
          <form class="space-y-4 md:space-y-6" action="#">
            <div>
              <label
                for="email"
                class="block mb-2 text-sm font-medium text-black"
                >Correo</label
              >
              <input
                type="email"
                name="email"
                id="email"
                class="bg-gray-50 border border-gray-300 text-black sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5"
                placeholder="name@company.com"
                required=""
              />
            </div>
            <button
              type="submit"
              class="w-full text-white bg-purple-500 hover:bg-purple-400 font-bold py-2 px-4 border-b-4 border-purple-700 hover:border-purple-500 rounded"
            >
              Continuar
            </button>
          </form>
        </div>
      </div>
    </section>
  </div>
</template>
