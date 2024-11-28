import { useEffect, useState } from "react";
import { deleteComment, getCommentsByPostId } from "../../services/CommentService";

function CommentList({ PostId }) {
    const [comments, setComments] = useState([]);

    useEffect(() => {
        async function fetchComments() {
            const data = await getCommentsByPostId(PostId);
            setComments(data);
        }

        fetchComments();
    }, [PostId]);

    async function handleDelete(commentId) {
        const confirmed = window.confirm("Are you sure you want to delete this comment?");
        if (confirmed) {
            try {
                await deleteComment(PostId, commentId);
                setComments(comments.filter((comment) => comment.id !== commentId));
            } catch (error) {
                console.error("Failed to delete comment:", error);
            }
        }
    }

    return (
        <div style={{ padding: "10px", maxWidth: "600px", margin: "0 auto" }}>
            <h3 style={{ textAlign: "center", marginBottom: "20px", fontSize: "1.5em" }}>Comments</h3>
            {console.log(comments)}

            {comments.length > 0 ? (
                comments.map((comment) => (
                    <div
                        key={comment.id}
                        style={{
                            display: "flex",
                            alignItems: "center",
                            justifyContent: "space-between",
                            marginBottom: "10px",
                            padding: "10px",
                            border: "1px solid #ddd",
                            borderRadius: "5px",
                            backgroundColor: "#f9f9f9",
                            boxShadow: "0 2px 5px rgba(0, 0, 0, 0.1)",
                        }}
                    >
                        <p
                            style={{
                                flex: 1,
                                margin: "0",
                                fontSize: "1em",
                                wordBreak: "break-word",
                            }}
                        >
                            {comment.text}
                        </p>
                        <button
                            onClick={() => handleDelete(comment.id)}
                            style={{
                                marginLeft: "10px",
                                padding: "5px 10px",
                                backgroundColor: "#ff4d4d",
                                color: "#fff",
                                border: "none",
                                borderRadius: "5px",
                                cursor: "pointer",
                                fontSize: "0.9em",
                            }}
                        >
                            Delete
                        </button>
                    </div>
                ))
            ) : (
                <p style={{ textAlign: "center", fontSize: "1em", color: "#666" }}>No comments available</p>
            )}
        </div>
    );
}

export default CommentList;
