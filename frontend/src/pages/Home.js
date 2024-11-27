import PostForm from "../components/post/PostForm";

function Home(){

    function refreshPage(){
        window.location.reload();
    }

    return(
        <div>
            <h1>Blog App</h1>
            <PostForm onPostAdded={refreshPage} />
        </div>
    );
}

export default Home;