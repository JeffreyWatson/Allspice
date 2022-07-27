<template>
	<div class="col-4">
		<div class="card m-4 bg-grey rounded elevation-5 selectable tall">
			<div
				class="card-body"
				:style="`background-repeat: no-repeat; background-size: cover; background-image: url(${recipes.picture})`"
			>
				<div class="row">
					<div class="card d-flex flex-column align-items-center">
						<div class="text-uppercase text-danger">
							{{ recipes.title }}
						</div>
						<div class="text-danger">{{ recipes.subtitle }}</div>
						<div class="text-danger">Category: {{ recipes.category }}</div>
					</div>
				</div>
			</div>
			<div class="d-flex flex-row justify-content-between">
				<button
					v-if="recipes.creator.id == account.id"
					@click.prevent="deleteRecipe"
					class="btn selectable"
				>
					<i class="mdi mdi-delete-forever-outline text-danger"></i>
				</button>

				<div class="p-2 me-2">
					<i class="mdi mdi-heart-outline"></i>
				</div>
			</div>
		</div>
	</div>
</template>


<script>
import { computed } from '@vue/reactivity';
import { AppState } from '../AppState';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';
import { recipesService } from '../services/RecipesService';
export default {
	props: { recipes: { type: Object, required: true } },
	setup(props) {
		return {
			account: computed(() => AppState.account),
			async deleteRecipe() {
				try {
					await recipesService.deleteRecipe(props.recipes.id)
					Pop.toast('Recipe has been deleted.', 'success')
				} catch (error) {
					logger.error(error)
					Pop.toast(error.message, 'error')
				}
			},
		}
	}
}
</script>


<style lang="scss" scoped>
.special-card {
	background-color: rgba(245, 245, 245, 1);
	opacity: 0.4;
	font-weight: 900;
}

.tall {
	height: 400px;
}
</style>