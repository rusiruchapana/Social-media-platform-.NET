import axios from "axios";

const API_BASE_URL = "http://localhost:5280/api/posts";



export async function createPost(posts) {
    const response = await axios.post(API_BASE_URL, posts);
    return response.data;
}


export async function getPosts(){
    const response = await axios.get(API_BASE_URL);
    return response.data;
}


