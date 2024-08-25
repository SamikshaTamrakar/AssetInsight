import React, { useState, useEffect } from 'react';
import assetService from '../../Services/AssetService';
import "./Investor.css";
import { useParams } from 'react-router-dom';

const InvestorItems = () => {
    const [investorData, setdata] = useState({ investor: [] });
    const { assetClass } = useParams();
    console.log(assetClass);
    useEffect(() => {
        const fetchPostList = async () => {
            const data = await assetService.getAllCommitments(assetClass);
            setdata({ investor: data });
            console.log(investor);
        };
        fetchPostList();
    }, [setdata]);

    return (
        investorData == undefined? <p>Loading investor...</p>:
        <div className="container">
            <h1>Investors</h1>
            <div className="tableDiv">
                <table className="table">
                    <thead className="thead">
                        <tr className="tr">
                            <th className="th">ID</th>
                            <th className="th">Name</th>
                            <th className="th">Type</th>
                                <th className="th">Date Added</th>
                                <th className="th">Address</th>
                                <th className="th">Total Commitment</th>
                        </tr>
                    </thead>
                    <tbody className="tbody">
                        {investorData.investor &&
                            investorData.investor.map((item) => (
                                <tr className="tr" key={item.id}>
                                    <td className="td">{item.id}</td>
                                    <td className="td">{item.investorName}</td>
                                    <td className="td">{item.investorType}</td>
                                    <td className="td">{item.investorDateAdded}</td>
                                    <td className="td">{item.investorCountry}</td>
                                    <td className="td">{item.totalCommitment}</td>
                                </tr>
                            ))}
                    </tbody>
                </table>
            </div>
        </div>

    );
};

export default InvestorItems;