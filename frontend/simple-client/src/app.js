// Java Script
import '../node_modules/bootstrap/dist/js/bootstrap.js';

import '../node_modules/bootstrap-fileinput/js/plugins/piexif';
import '../node_modules/bootstrap-fileinput/js/plugins/sortable';

import '../node_modules/bootstrap-fileinput/js/fileinput';
import '../node_modules/bootstrap-fileinput/themes/fas/theme';
import '../node_modules/bootstrap-fileinput/js/locales/de';

// Stylesheets
import '../node_modules/bootstrap/dist/css/bootstrap.min.css';
import '../node_modules/bootstrap-fileinput/css/fileinput.css';
import './styles.css';

const urlBaseLocal = 'http://localhost:7001';
const urlBaseCloud = 'https://func-financemanager-dev.azurewebsites.net';
const urlUploadInvoices = 'api/invoice/upload';

jQuery(() => {

    let action = `${urlBaseLocal}/${urlUploadInvoices}`;
    if (document.location.hostname !== "localhost") {
        action = `${urlBaseCloud}/${urlUploadInvoices}`;
    }

    document.getElementById('frmInvoiceUpload').action = action;
    console.log(document.getElementById('frmInvoiceUpload').action);
});
