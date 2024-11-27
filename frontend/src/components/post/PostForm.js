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
        <form 
            onSubmit={handleSubmit} 
            style={{
                display: "flex",
                flexDirection: "column",
                width: "300px",
                margin: "auto",
                padding: "20px",
                border: "1px solid #ccc",
                borderRadius: "8px",
                boxShadow: "0 4px 8px rgba(0, 0, 0, 0.1)",
                backgroundColor: "#f9f9f9"
            }}
        >
            <input 
                type="text"
                placeholder="Title"
                value={Title}
                onChange={(e) => setTitle(e.target.value)}
                style={{
                    marginBottom: "10px",
                    padding: "10px",
                    fontSize: "16px",
                    border: "1px solid #ddd",
                    borderRadius: "4px"
                }}
            />

            <textarea
                placeholder="Content"
                value={Content}
                onChange={(e) => setContent(e.target.value)}
                required
                style={{
                    marginBottom: "10px",
                    padding: "10px",
                    fontSize: "16px",
                    border: "1px solid #ddd",
                    borderRadius: "4px",
                    resize: "none",
                    height: "100px"
                }}
            />

            <button 
                type="submit"
                style={{
                    padding: "10px 20px",
                    fontSize: "16px",
                    backgroundColor: "#007BFF",
                    color: "white",
                    border: "none",
                    borderRadius: "4px",
                    cursor: "pointer"
                }}
            >
                Add Post
            </button>
        </form>

    );
}

export default PostForm;