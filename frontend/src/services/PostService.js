import axios from "axios";

const API_BASE_URL = "http://localhost:5280/api/posts";



export const createPost = async (posts) =>{
    const response = await axios.post(API_BASE_URL , posts);
    return response.data;
};





