import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import {Register} from './pages/Register.tsx'
import './App.css'

function App() {
  return (
    <Router>
      <Routes>
        <Route path='Account/register' element={<Register/>}/>
      </Routes>
    </Router>
  )
}

export default App
