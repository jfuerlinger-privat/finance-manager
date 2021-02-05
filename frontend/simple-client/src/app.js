// Java Script
import '../node_modules/bootstrap/dist/js/bootstrap.js';

import '../node_modules/bootstrap-fileinput/js/plugins/piexif';
import '../node_modules/bootstrap-fileinput/js/plugins/sortable';

import '../node_modules/bootstrap-fileinput/js/fileinput';
import '../node_modules/bootstrap-fileinput/themes/fas/theme';
import '../node_modules/bootstrap-fileinput/js/locales/de';

const axios = require('axios').default;

// Stylesheets
import '../node_modules/bootstrap/dist/css/bootstrap.min.css';
import '../node_modules/bootstrap-fileinput/css/fileinput.css';
import './styles.css';

const urlBaseLocal = 'http://localhost:7071';
const urlBaseCloud = 'https://func-financemanager-dev.azurewebsites.net';
const urlUploadInvoices = 'api/invoice/upload';

jQuery(async () => {

    let baseUrl = urlBaseLocal;
    if (document.location.hostname !== "localhost") {
        baseUrl = urlBaseCloud;
    }

    axios.defaults.baseURL = baseUrl;

    try {
        let tags = (await axios.get('/api/tags')).data;
        tags.map(tag => {
            console.log(tag);
            let select = document.getElementById('tags');
            var option = document.createElement("option");
            option.text = tag;
            select.add(option);
        });


    } catch (error) {
        console.log(error);
    }

    document.getElementById('frmInvoiceUpload').action = `${baseUrl}/${urlUploadInvoices}`;
    console.log(document.getElementById('frmInvoiceUpload').action);
});
