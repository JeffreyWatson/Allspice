<template>
	<div class="text-center">
		<h1>Good Day {{ account.name }}</h1>
		<img class="img-fluid rounded" :src="account.picture" alt="" />
		<p>{{ account.email }}</p>
	</div>
	<div class="container text-black">
		<div class="row justify-content-center">
			<div class="col-6 outline-black">
				<form
					class="d-flex flex-column"
					action=""
					@submit.prevent="saveAccount"
				>
					<label for="">Whats your name?</label>
					<input type="text" v-model="editable.name" />
					<label for="">Picture</label>
					<input type="text" v-model="editable.picture" />
					<label for="">Email</label>
					<input type="text" v-model="editable.email" />
					<button class="btn btn-primary mt-3">Save Changes</button>
				</form>
			</div>
		</div>
	</div>
</template>

<script>
import { computed, ref, watchEffect } from 'vue'
import { AppState } from '../AppState'
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';
import { accountService } from '../services/AccountService';
export default {
	name: 'Account',
	setup() {
		const editable = ref({});
		watchEffect(() => {
			AppState.account;
			logger.log("account changes", AppState.account, editable.value);
			editable.value = { ...AppState.account };
		})
		return {
			editable,
			account: computed(() => AppState.account),
			async saveAccount() {
				try {
					await accountService.editAccount(editable.value);
				} catch (error) {
					logger.error(error);
					Pop.toast(error.message, "error");
				}
			}
		}
	}
}
</script>

<style scoped>
img {
	max-width: 100px;
}
</style>
