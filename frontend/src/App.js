import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Home from './pages/Home';
import PostPage from './pages/PostPage';
import RegisterForm from './components/RegisterForm';

function App() {
  return (
    <Router>
        <Routes>
            <Route path="/" element={<Home />} />
            <Route path='/register' element={<RegisterForm />} />

            <Route path="/posts/:id" element={<PostPage />} />
        </Routes>
    </Router>
  );
}

export default App;
