function getDateFromDDMMYYYY(dateString) {
    var parts = dateString.split('.');
    let mydate = new Date(Date.UTC(parts[2], parts[1] - 1, parts[0])); 
    return mydate; 
}

function getDateFromMMDDYYYY(dateString) {
    var parts = dateString.split('/');
    let mydate = new Date(Date.UTC(parts[2], parts[0] - 1, parts[1])); 
    return mydate; 
}
