import axios from 'axios';

const baseURL = 'http://localhost:5039/Commitment'; 
const commitmentService = {
    getAllCommitments: async () => {
        const response = await axios.get(baseURL);
        console.log("Response",response)
        return response.data;
    },
};

export default commitmentService