<template>
	<!-- Button trigger modal -->
	<button
		type="button"
		class="btn btn-primary btn-lg"
		data-bs-toggle="modal"
		data-bs-target="#modelId"
	>
		Launch
	</button>

	<!-- Modal -->
	<div
		class="modal fade"
		id="modelId"
		tabindex="-1"
		role="dialog"
		aria-labelledby="modelTitleId"
		aria-hidden="true"
	>
		<div class="modal-dialog" role="document">
			<div class="modal-content">
				<div class="modal-header">
					<h5 class="modal-title">Modal title</h5>
					<button
						type="button"
						class="btn-close"
						data-bs-dismiss="modal"
						aria-label="Close"
					></button>
				</div>
				<div class="modal-body">Body</div>
				<div class="modal-footer">
					<button
						type="button"
						class="btn btn-secondary"
						data-bs-dismiss="modal"
					>
						Close
					</button>
					<button type="button" class="btn btn-primary">Save</button>
				</div>
			</div>
		</div>
	</div>
</template>


<script>
import { Modal } from "bootstrap";
export default {

}
</script>


<style lang="scss" scoped>
</style>