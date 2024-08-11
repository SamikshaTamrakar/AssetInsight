import React, { useState, useEffect } from 'react';
import investorService from './../../Services/InvestorService';
import Button from './../Buttons/Button';
import * as ReactBootStrap from "react-bootstrap";
import "./Investor.css";

const InvestorItems = () => {
    const [investorData, setdata] = useState({ investor: [] });

    useEffect(() => {
        const fetchPostList = async () => {
            const data = await investorService.getAllInvestors();
            setdata({ investor: data });
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
                                <th className="th">Total Commitment</th>
                        </tr>
                    </thead>
                    <tbody className="tbody">
                        {investorData.investor &&
                            investorData.investor.map((item) => (
                                <tr className="tr" key={item.id}>
                                    <td className="td">{item.id}</td>
                                    <td className="td">{item.name}</td>
                                    <td className="td">{item.type}</td>
                                    <td className="td">{item.dateAdded}</td>
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