<template>
	<form @submit.prevent="searchRecipes" class="show">
		<input v-model="search" type="text" placeholder="Search Recipes" />
	</form>
</template>


<script>
import { computed, ref } from '@vue/reactivity';
import { AppState } from '../AppState';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';
export default {
	setup() {
		const search = ref("");
		return {
			search,
			searchBar: computed(() => AppState.searchBar),
			async searchRecipes() {
				try {
					logger.log("searching", search.value);
					await recipesService.searchRecipes(`query=${search.value}`);
				} catch (error) {
					Pop.toast(error.message, "error");
					logger.error(error);
				}
			}
		}
	}
}
</script>


<style lang="scss" scoped>
</style>