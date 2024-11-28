import { useState } from "react";
import { createComment } from "../../services/CommentService";

function CommentForm({PostId , commentAdded}){

    const [Text, setText] = useState("");

    async function handleSubmit(e){
        e.preventDefault();
        await createComment({Text , PostId});
        setText("");
        commentAdded();
    }


    return(
        <form onSubmit={handleSubmit}>
            <input
                type="text"
                placeholder="Add a comment..."
                value={Text}
                onChange={(e) => setText(e.target.value)}
                required
            />
            <button type="submit">Add Comment</button>
        </form>
    );
}

export default CommentForm;
