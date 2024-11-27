import { useState } from "react";
import { createPost } from "../../services/PostService";

function PostForm({onPostAdded}){

    const[Title , setTitle] = useState("");
    const[Content , setContent] = useState("");

    async function handleSubmit(e) {
        e.preventDefault();
        await createPost({Title , Content});
        setTitle("");
        setContent("");
        onPostAdded();
    }


    return(
        <form onSubmit={handleSubmit}>
            <input 
                type="text"
                placeholder="Title"
                value={Title}
                onChange={(e)=> setTitle(e.target.value)}
            />

            <textarea
                placeholder="Content"
                value={Content}
                onChange={(e) => setContent(e.target.value)}
                required
            />

            <button type="submit">Add Post</button>
        </form>
    );
}

export default PostForm;