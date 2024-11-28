import { useEffect, useState } from "react";
import { getPosts } from "../../services/PostService";
import { Link } from 'react-router-dom';

function PostList(){

    const[posts , setPosts] = useState([]);

    useEffect(()=>{
        async function fetchPosts(){
            const data = await getPosts();
            setPosts(data);
        }

        fetchPosts();
    }, []);

    return(
        <div>
            <h2>Posts</h2>    

            <table 
                className="posts-table" 
                style={{
                    width: "100%", 
                    borderCollapse: "collapse", 
                    boxShadow: "0 4px 6px rgba(0, 0, 0, 0.1)", 
                    margin: "20px 0", 
                    fontFamily: "'Segoe UI', Tahoma, Geneva, Verdana, sans-serif"
                }}
                >
                <thead>
                    <tr 
                    style={{
                        backgroundColor: "#4CAF50", 
                        color: "white", 
                        textAlign: "left", 
                        padding: "12px"
                    }}
                    >
                    <th style={{ padding: "12px", fontSize: "16px" }}>Title</th>
                    <th style={{ padding: "12px", fontSize: "16px" }}>Content</th>
                    <th style={{ padding: "12px", fontSize: "16px" }}>Details</th>
                    </tr>
                </thead>
                <tbody>
                    {posts.map((post) => (
                    <tr 
                        key={post.id} 
                        style={{
                        borderBottom: "1px solid #ddd", 
                        transition: "background-color 0.3s ease"
                        }}
                        onMouseEnter={(e) => e.target.style.backgroundColor = "#f1f1f1"}
                        onMouseLeave={(e) => e.target.style.backgroundColor = ""}
                    >
                        <td style={{ padding: "12px", fontSize: "14px" }}>{post.title}</td>
                        <td style={{ padding: "12px", fontSize: "14px" }}>{post.content}</td>
                        <td style={{ padding: "12px", fontSize: "14px" }}>
                        <Link 
                            to={`/posts/${post.id}`} 
                            style={{
                            color: "#4CAF50", 
                            textDecoration: "none", 
                            fontWeight: "bold", 
                            transition: "color 0.3s"
                            }}
                            onMouseEnter={(e) => e.target.style.color = "#45a049"}
                            onMouseLeave={(e) => e.target.style.color = "#4CAF50"}
                        >
                            View Details
                        </Link>
                        </td>
                    </tr>
                    ))}
                </tbody>
            </table>

        </div>
    );
}

export default PostList;