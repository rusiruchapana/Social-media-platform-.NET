import PostForm from "../components/post/PostForm";
import PostList from "../components/post/PostList";

function Home(){

    function refreshPage(){
        window.location.reload();
    }

    return(
        <div>
            <h1 style={{ 
                textAlign: "center", 
                color: "#333", 
                fontSize: "24px", 
                fontWeight: "bold", 
                marginBottom: "20px" 
            }}>
                Blog App
            </h1>
            <PostForm onPostAdded={refreshPage} />
            <PostList />
        </div>
    );
}

export default Home;