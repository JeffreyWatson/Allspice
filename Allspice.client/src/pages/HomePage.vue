<template>
	<div class="row gx-0">
		<Recipe v-for="r in recipes" :key="r.id" :recipes="r" />
	</div>
	<div class="position-fixed bottom-0 end-0 p-5">
		<i
			class="mdi mdi-plus-box-outline fs-1 selectable"
			title="Add Recipe"
			@click="createRecipe"
		></i>
	</div>
</template>


<script>
import { computed, onMounted } from '@vue/runtime-core'
import { recipesService } from '../services/RecipesService'
import { logger } from '../utils/Logger'
import Pop from '../utils/Pop'
import { AppState } from '../AppState'
export default {
	setup() {
		onMounted(async () => {
			try {
				await recipesService.getRecipes()
			} catch (error) {
				logger.error(error)
				Pop.toast(error.message, 'error')
			}
		})
		return {
			recipes: computed(() => AppState.recipes)
		}
	}
}
</script>


<style lang="scss" scoped>
.add {
	height: 85px;
	width: 85px;
}
</style>
