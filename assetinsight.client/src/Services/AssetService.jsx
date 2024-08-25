import axios from 'axios';

const baseURL = 'http://localhost:5039/Asset/filter/assetClass'; 
const assetService = {
    getAllCommitments: async (assetClass) => {
        console.log("BaseURL", baseURL.concat("?assetClass =" + assetClass));
        const response = await axios.get(baseURL.concat("?assetClass=" + assetClass));
        console.log("Response", response);
        return response.data;
    },
};

export default assetService