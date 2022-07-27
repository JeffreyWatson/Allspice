<template>
	<header
		class="
			d-flex
			header-bg
			gx-0
			elevation-3
			justify-content-between
			align-items-center
		"
	>
		<div class="d-flex flex-row">
			<i
				class="mdi mdi-magnify fs-1 text-dark selectable ms-2"
				data-bs-toggle="collapse"
				data-bs-target="#collapseExample"
			></i>
			<Search class="ms-3 mt-3 collapse" id="collapseExample" />
		</div>
		<Login />
	</header>
	<div class="row justify-content-center bg-grey gx-0">
		<div class="col-6 d-flex mt-3 justify-content-center overlap">
			<div
				class="card-body bg-dark rounded d-flex flex-row justify-content-around"
			>
				<router-link class="text-white d-flex" :to="{ name: 'Home' }">
					<div class="selectable"><b>Home</b></div></router-link
				>
				<div class="selectable"><b>My Recipes</b></div>
				<div class="selectable"><b>Favorites</b></div>
			</div>
		</div>
	</div>
</template>


<script>
export default {
	setup() {
		return {
		}
	}
}
</script>


<style lang="scss" scoped>
.header-bg {
	height: 250px;
	background-image: url("../assets/img/headerimg.jpg");
	background-position: center;
	background-repeat: no-repeat;
	background-size: cover;
	min-height: 17vh;
}

.overlap {
	transform: translateY(-45px);
}
</style>