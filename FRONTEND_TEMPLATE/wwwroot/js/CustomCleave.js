new Cleave('.cleavePhone', {
    prefix: '+977',
    delimiter: ' ',
    phone: true,
    phoneRegionCode: 'NP'
});

new Cleave('.cleaveDate', {
    date: true,
    delimiter: '-',
    datePattern: ['d', 'm', 'Y']
});

new Cleave('.cleaveMoney', {
    delimiter: ',',
    numeral: true,
    numeralThousandsGroupStyle: 'lakh'
});