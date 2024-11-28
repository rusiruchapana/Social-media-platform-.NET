import { useEffect, useState } from "react";
import { deleteComment, getCommentsByPostId } from "../../services/CommentService";

function CommentList({PostId}){

    const[comments , setComments] = useState([]);

    useEffect(()=>{

        async function fetchComments(){
            const data = await getCommentsByPostId(PostId);
            setComments(data);
        }

        fetchComments();

    } , [PostId]);


    async function handleDelete(commentId){
        const confirmed = window.confirm("Are you sure you want to delete this comment?");
        if(confirmed){
            try {
                await deleteComment(PostId , commentId);
                setComments(comments.filter((comment) => comment.id !== commentId));
            } catch (error) {
                console.error("Failed to delete comment:", error);
            }
        }
    
    }



    return(
        <div>
            <h3>Comments</h3>
            {console.log(comments)}
            
            {comments.length > 0 ? (
                comments.map((comment) => (
                    <div key={comment.id} style={{ display: "flex", alignItems: "center", marginBottom: "10px" }}>
                    <p style={{ flex: 1 }}>{comment.text}</p>
                    <button  onClick={()=> handleDelete(comment.id)} style={{ marginLeft: "10px" }}>
                      Delete
                    </button>
                  </div>
                ))
            ) : (
                <p>No comments available</p>
            )}

        </div>
    );
}

export default CommentList;