import React, { useState, useEffect } from 'react';
import assetService from '../../Services/AssetService';
import Button from './../Buttons/Button';
import * as ReactBootStrap from "react-bootstrap";
import "./Commitment.css";
import { useNavigate } from 'react-router-dom';
import { useTable, useFilters } from 'react-table';

const CommitmentItems = () => {
    const [assetServieData, setdata] = useState({ commitment: [] });

    //const [data, setData] = useState(null);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);

    useEffect(() => {
        
        fetchPostList("All");
        console.log("data", assetServieData);
    }, []);

    const fetchPostList = async (assetClass) => {
        setLoading(true);
        setError(null);
        try {
            const data = await assetService.getAllCommitments(assetClass ? assetClass : "All");
            setdata({ commitment: data });
            console.log(data);
        } catch (err) {
            setError(err.message);
        } finally {
            setLoading(false);
        }
    };
    const navigate = useNavigate();

    const handleInvestorCall = (assetClass) => {
        navigate('/investors/'+assetClass);
    };

    // Function to handle click
    const handleFilterButtonClick = (assetClass) => {
        console.log("onclick")
        fetchPostList(assetClass);
    };

    return (
        assetServieData == undefined ? <p>Loading Commitments</p> :
            <div className="container">
                <h1>Commitment</h1>
                <div className="buttons">
                    <button onClick={() => handleFilterButtonClick('All')}>All</button>
                    <button onClick={() => handleFilterButtonClick('Hedge Funds')}>Hedge Funds</button>
                    <button onClick={() => handleFilterButtonClick('Private Equity')}>Private Equity</button>
                    <button onClick={() => handleFilterButtonClick('Real Estate')}>Real Estate</button >
                    <button onClick={() => handleFilterButtonClick('Infrastructure')}>Infrastructure</button >
                    <button onClick={() => handleFilterButtonClick('Natural Resources')}>Natural Resources</button >
            </div>
                <div className="tableDiv">
                    {/*<ReactBootStrap.Table striped bordered hover className="tableDiv">*/}
                    <table className="table">
                        <thead className="thead">
                            <tr className="tr">
                                <th className="th">ID</th>
                                <th className="th">Asset Class</th>
                                <th className="th">Currency</th>
                                <th className="th">Amount</th>
                            </tr>
                        </thead>
                        <tbody className="tbody">
                            {assetServieData.commitment &&
                                assetServieData.commitment.map((item) => (
                                    <tr className="tr" key={item.id}>
                                        <td className="td">{item.id}</td>
                                        <td className="td" onClick={() => handleInvestorCall(item.assestClass)}>{item.assestClass}</td>
                                        <td className="td">{item.currency}</td>
                                        <td className="td">{item.amount}</td>
                                    </tr>
                                ))}
                        </tbody>
                    </table>
                    {/*</ReactBootStrap.Table>*/}
                </div>
            </div>

    );
};

export default CommitmentItems;