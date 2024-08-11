import {useState } from 'react';
import './App.css';
import CommitmentItems from './Components/CommitmentTable/Commitment';
import InvestorItems from './Components/InvestorTable/Investor';
function App() {
    const [refreshCommitment, setCommitment] = useState(false);

    const handleCommitmentAdded = () => {
        setCommitment(!refreshCommitment); // Toggle refresh state to trigger re-render
    };

    //const [refreshInvestor, setInvestor] = useState(false);

    //const handleInvestorAdded = () => {
    //    setInvestor(!refreshInvestor); // Toggle refresh state to trigger re-render
    //};

    return (
        <div>
            <CommitmentItems key={refreshCommitment} />
            {/*<InvestorItems key={refreshInvestor}/>*/}
            {/*<ProductForm onProductAdded={handleProductAdded} />*/}
        </div>
    );
}

export default App;