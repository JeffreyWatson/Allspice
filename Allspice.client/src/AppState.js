import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  account: {},
  recipes: [],
  ingredients: [],
  steps: [],
  activeRecipes: {},
  userRecipes: [],
  query: '',
  searchBar: false,
  formRecipe: {},
})
