import { useEffect, useState } from "react";
import { getPosts } from "../../services/PostService";

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
                    
            <table style={{ width: '100%', borderCollapse: 'collapse', marginTop: '20px' }}>
                <thead>
                    <tr>
                        <th style={{ border: '1px solid #ddd', padding: '8px', backgroundColor: '#f4f4f4', textAlign: 'left' }}>ID</th>
                        <th style={{ border: '1px solid #ddd', padding: '8px', backgroundColor: '#f4f4f4', textAlign: 'left' }}>Title</th>
                        <th style={{ border: '1px solid #ddd', padding: '8px', backgroundColor: '#f4f4f4', textAlign: 'left' }}>Content</th>
                    </tr>
                </thead>
                <tbody>
                    {posts.map((p) => (
                        <tr key={p.id} style={{ border: '1px solid #ddd' }}>
                            <td style={{ border: '1px solid #ddd', padding: '8px' }}>{p.id}</td>
                            <td style={{ border: '1px solid #ddd', padding: '8px' }}>{p.title}</td>
                            <td style={{ border: '1px solid #ddd', padding: '8px' }}>{p.content}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}

export default PostList;