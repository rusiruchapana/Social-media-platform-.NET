import { useParams } from "react-router-dom";
import CommentForm from "../components/comment/CommentForm";
import CommentList from "../components/comment/CommentList";

function PostPage(){

    const {id} = useParams();

    function refreshComments() {
        window.location.reload();
    }



    return(
        <div>
            <h2>Post Details</h2>
            <CommentForm PostId={id} commentAdded={refreshComments} />
            <CommentList PostId={id} />
        </div>
    );
}

export default PostPage;