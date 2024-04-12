<script setup lang="ts">
    import CarCalculator from './components/CarCalculator.vue'
</script>

<template>
    <header>
        <div class="logo">
            <img src="./assets/logo.svg" width="100%" height="100%" />
        </div>
    </header>
    <main>
        <CarCalculator />
    </main>
</template>

<style scoped>
    header {
        line-height: 1.5;
        display: flex;
        justify-content: center;
        margin-bottom: 3rem;
    }

    .logo {
        display: flex;
        align-content: center;
        justify-content: center;
        border-radius: 10px;
        width: 100%;
        max-width: 400px;
    }

        .logo:hover {
            animation : pulse ease-in-out 2s;
            
        }

    @keyframes pulse {
        from {
            transform: scale3d(1, 1, 1);
        }

        50% {
            transform: scale3d(1.05, 1.05, 1.05);
        }

        to {
            transform: scale3d(1, 1, 1);
        }
    }
</style>
