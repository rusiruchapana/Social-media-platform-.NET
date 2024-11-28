import { useEffect, useState } from "react";
import { getCommentsByPostId } from "../../services/CommentService";

function CommentList({PostId}){

    const[comments , setComments] = useState([]);

    useEffect(()=>{

        async function fetchComments(){
            const data = await getCommentsByPostId(PostId);
            setComments(data);
        }

        fetchComments();

    } , [PostId]);




    return(
        <div>
            <h3>Comments</h3>
            {console.log(comments)}
            
            {comments.length > 0 ? (
                comments.map((comment) => (
                <div key={comment.id}>
                    <p>{comment.text}</p>
                    <button>Delete</button>
                </div>
                ))
            ) : (
                <p>No comments available</p>
            )}

        </div>
    );
}

export default CommentList;