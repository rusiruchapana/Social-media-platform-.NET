import { useState } from "react";
import { useNavigate } from "react-router-dom";

function LoginForm(){

    const[Email , setEmail] = useState("");
    const[PasswordHash , setPassword] = useState("");
    const[error , setError] = useState("");
    const navigate = useNavigate();


    return(
        <div>
            <h2>Login</h2>
            <form>
                <input
                    type="text"
                    placeholder="Username"
                    value={Email}
                    onChange={(e)=> setEmail(e.target.value)}
                    required
                />

                <input
                    type="text"
                    placeholder="Password"
                    value={PasswordHash}
                    onChange={(e)=> setPassword(e.target.value)}
                    required
                />

                <button type="submit"></button>
            </form>
        </div>
    );
}


export default LoginForm;