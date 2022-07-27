<template>
	<NewNav />
	<main class="gx-0 bg-grey">
		<router-view />
	</main>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
export default {
	name: 'App',
	setup() {
		return {
			appState: computed(() => AppState),
		}
	}
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";
</style>
