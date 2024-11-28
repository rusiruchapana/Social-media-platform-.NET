import axios from "axios";

const API_BASE_URL = "http://localhost:5280/api/Comments";

export async function createComment(comment){
    const response = await axios.post(API_BASE_URL , comment);
    return response.data;
}


export async function getCommentsByPostId(PostId){
    const response = await axios.get(`${API_BASE_URL}/${PostId}`);
    return response.data;
}


export async function deleteComment(PostId , Id){
    await axios.delete(`${API_BASE_URL}/${PostId}/comments/${Id}`);
}