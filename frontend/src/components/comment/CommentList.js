import { useEffect, useState } from "react";
import { deleteComment, getCommentsByPostId, updateComment } from "../../services/CommentService"; // Import the update service

function CommentList({ PostId }) {
    const [comments, setComments] = useState([]);
    const [editingCommentId, setEditingCommentId] = useState(null); // Track which comment is being edited
    const [updatedText, setUpdatedText] = useState(""); // Store updated text for the comment

    // Fetch comments when component mounts or PostId changes
    useEffect(() => {
        async function fetchComments() {
            const data = await getCommentsByPostId(PostId);
            setComments(data);
        }

        fetchComments();
    }, [PostId]);

    // Function to handle delete logic
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

    // Function to handle update logic
    async function handleUpdate(commentId) {
        try {
            const updatedComment = await updateComment(PostId, commentId, { text: updatedText }); // Call the update API
            setComments(
                comments.map((comment) =>
                    comment.id === commentId ? { ...comment, text: updatedComment.text } : comment
                )
            );
            setEditingCommentId(null); // Exit edit mode
            setUpdatedText(""); // Clear the input field
        } catch (error) {
            console.error("Failed to update comment:", error);
        }
    }

    return (
        <div style={{ padding: "10px", maxWidth: "600px", margin: "0 auto" }}>
            <h3 style={{ textAlign: "center", marginBottom: "20px", fontSize: "1.5em" }}>Comments</h3>
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
                        {editingCommentId === comment.id ? (
                            // Editable input field
                            <input
                                type="text"
                                value={updatedText}
                                onChange={(e) => setUpdatedText(e.target.value)}
                                style={{
                                    flex: 1,
                                    margin: "0 10px 0 0",
                                    padding: "5px",
                                    fontSize: "1em",
                                    border: "1px solid #ddd",
                                    borderRadius: "5px",
                                }}
                            />
                        ) : (
                            // Display comment text
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
                        )}

                        {editingCommentId === comment.id ? (
                            // Save button for update
                            <button
                                onClick={() => handleUpdate(comment.id)}
                                style={{
                                    marginLeft: "10px",
                                    padding: "5px 10px",
                                    backgroundColor: "#4CAF50",
                                    color: "#fff",
                                    border: "none",
                                    borderRadius: "5px",
                                    cursor: "pointer",
                                    fontSize: "0.9em",
                                }}
                            >
                                Save
                            </button>
                        ) : (
                            // Edit button
                            <button
                                onClick={() => {
                                    setEditingCommentId(comment.id); // Enter edit mode
                                    setUpdatedText(comment.text); // Set initial text
                                }}
                                style={{
                                    marginLeft: "10px",
                                    padding: "5px 10px",
                                    backgroundColor: "#007BFF",
                                    color: "#fff",
                                    border: "none",
                                    borderRadius: "5px",
                                    cursor: "pointer",
                                    fontSize: "0.9em",
                                }}
                            >
                                Edit
                            </button>
                        )}

                        {/* Delete button */}
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
