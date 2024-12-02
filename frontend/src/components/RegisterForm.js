import { useState } from "react";
import { useNavigate } from "react-router-dom";
import api from "../utils/api";

function RegisterForm(){

    const[Username , setUsername] = useState("");
    const[Email , setEmail] = useState("");
    const[PasswordHash , setPassword] = useState("");
    const[error , setError] = useState("");
    const navigate = useNavigate();

    async function handleSubmit(e){
        e.preventDefault();
        try {
            await api.post("/UserRegister" , {Username, Email, PasswordHash});
            navigate("/login");
        } catch (error) {
            setError(error.response.data.message || "Registration failed");
        }
    }
    


    return(
        <div>
            <h2>Register</h2>
            {error && <p style={{ color: 'red' }}>{error}</p>}
            <form onSubmit={handleSubmit}>
                <input
                    type="text"
                    placeholder="Username"
                    value={Username}
                    onChange={(e)=> setUsername(e.target.value)}
                    required
                />

                <input
                    type="text"
                    placeholder="Email"
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

                <button type="submit">Register</button>

            </form>


        </div>
    );
}

export default RegisterForm;