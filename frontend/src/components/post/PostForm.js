import { useState } from "react";
import { createPost } from "../../services/PostService";

function PostForm({ onPostAdded }) {
    const [Title, setTitle] = useState("");
    const [Content, setContent] = useState("");

    async function handleSubmit(e) {
        e.preventDefault();
        await createPost({ Title, Content });
        setTitle("");
        setContent("");
        onPostAdded();
    }

    return (
        <div
            style={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                height: "100vh",
                backgroundColor: "#f4f4f9",
            }}
        >
            <form
                onSubmit={handleSubmit}
                style={{
                    display: "flex",
                    flexDirection: "column",
                    width: "100%",
                    maxWidth: "450px",
                    margin: "auto",
                    padding: "30px",
                    border: "1px solid #ddd",
                    borderRadius: "8px",
                    boxShadow: "0 4px 12px rgba(0, 0, 0, 0.15)",
                    backgroundColor: "#ffffff",
                }}
            >
                <h2
                    style={{
                        textAlign: "center",
                        color: "#333",
                        marginBottom: "20px",
                    }}
                >
                    Create a Post
                </h2>

                <input
                    type="text"
                    placeholder="Title"
                    value={Title}
                    onChange={(e) => setTitle(e.target.value)}
                    style={{
                        marginBottom: "15px",
                        padding: "12px",
                        fontSize: "16px",
                        border: "1px solid #ddd",
                        borderRadius: "4px",
                        outline: "none",
                        transition: "border-color 0.3s",
                    }}
                />

                <textarea
                    placeholder="Content"
                    value={Content}
                    onChange={(e) => setContent(e.target.value)}
                    required
                    style={{
                        marginBottom: "20px",
                        padding: "12px",
                        fontSize: "16px",
                        border: "1px solid #ddd",
                        borderRadius: "4px",
                        resize: "none",
                        height: "120px",
                        outline: "none",
                        transition: "border-color 0.3s",
                    }}
                />

                <button
                    type="submit"
                    style={{
                        padding: "12px 25px",
                        fontSize: "16px",
                        backgroundColor: "#007BFF",
                        color: "white",
                        border: "none",
                        borderRadius: "4px",
                        cursor: "pointer",
                        transition: "background-color 0.3s",
                    }}
                    onMouseOver={(e) => (e.target.style.backgroundColor = "#0056b3")}
                    onMouseOut={(e) => (e.target.style.backgroundColor = "#007BFF")}
                >
                    Add Post
                </button>
            </form>
        </div>
    );
}

export default PostForm;
