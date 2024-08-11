import React, { useState, useEffect } from 'react';
import commitmentService from './../../Services/CommitmentService';
import Button from './../Buttons/Button';
import * as ReactBootStrap from "react-bootstrap";
import "./Commitment.css";

const CommitmentItems = () => {
    const [commitmentdata, setdata] = useState({ commitment: [] });

    useEffect(() => {
        const fetchPostList = async () => {
            const  data = await commitmentService.getAllCommitments();
            setdata({ commitment: data });
            //console.log(data);
        };
        fetchPostList();
        console.log("data",commitmentdata);
    }, [setdata]);

    return (
        commitmentdata == undefined? <p>Loading Commitments</p>:
        <div className="container">
            <h1>Commitment</h1>
            <div className="buttons">
                <Button text="All" />
                <Button text="Hedge Funds" />
                <Button text="Private Equity" />
                <Button text="Real Estate" />
                <Button text="Infrastructure" />
                <Button text="Natural Resources" />
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
                        {commitmentdata.commitment &&
                            commitmentdata.commitment.map((item) => (
                                <tr className="tr" key={item.id}>
                                    <td className="td">{item.id}</td>
                                    <td className="td">{item.assestClass}</td>
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