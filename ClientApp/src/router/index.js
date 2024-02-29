import { createWebHistory, createRouter } from "vue-router";
import Home from "@/components/Home.vue";
import ListKnights from "@/components/ListKnights.vue";
import CreateKnights from "@/components/CreateKnight.vue";
import EditKnights from "@/components/EditKnights.vue";
import DetailsKnight from "@/components/DetailsKnight.vue";
import ListHeroes from "@/components/ListHeroes.vue";
import View from "@/components/View.vue";


const routes = [
    {
        path: "/",
        name: "Home",
        component: Home
    },
    {
        path: "/ListKnights",
        name: "ListKnights",
        component: ListKnights
    },
    {
        path: "/CreateKnights",
        name: "CreateKnights",
        component: CreateKnights
    },
    {
        path: "/EditKnights/:id",
        name: "EditKnights",
        component: EditKnights,
        props: true
    },
    {
        path: "/DetailsKnight/:id",
        name: "DetailsKnight",
        component: DetailsKnight,
        props: true
    },
    {
        path: "/ListHeroes",
        name: "ListHeroes",
        component: ListHeroes
    },
    {
        path: "/View/:id",
        name: "View",
        component: View,
        props: true
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});



export default router;