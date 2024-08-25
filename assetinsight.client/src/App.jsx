import {useState } from 'react';
import './App.css';
import CommitmentItems from './Components/CommitmentTable/Commitment';
import InvestorItems from './Components/InvestorTable/Investor';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';

function App() {    
    const [refreshCommitment, setCommitment] = useState(false);

    const handleCommitmentAdded = () => {
        setCommitment(!refreshCommitment); // Toggle refresh state to trigger re-render
    };

    return (
        <Router>
            <Routes>
                <Route path="/" element={<CommitmentItems />} />
                <Route path="/investors/:assetClass" element={<InvestorItems />} />
            </Routes>
        </Router>
        
    );
}

export default App;