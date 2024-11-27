import PostForm from "../components/post/PostForm";
import PostList from "../components/post/PostList";

function Home(){

    function refreshPage(){
        window.location.reload();
    }

    return(
        <div>
            <h1>Blog App</h1>
            <PostForm onPostAdded={refreshPage} />
            <PostList />
        </div>
    );
}

export default Home;