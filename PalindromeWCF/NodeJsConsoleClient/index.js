#!/usr/bin/env node
//
// Console client for c# SOAP service
//
'use strict';

const config = require('./config.json');
const soap = require('soap');
const readline = require('readline');

const dialog = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

// application loop
(function dialogLoop() {
    dialog.question('Enter a string: ', answer => {
        getLongestPrefix(answer)
            .then(longestPrefix => {
                console.log(`Longest prefix is '${Object.values(longestPrefix)[0]}'`);

                dialog.question('One more time? ', answer => {
                    if (!answer || answer.toLowerCase().startsWith('y')) {
                        dialogLoop();
                    } else {
                        dialog.close();

                        process.exit(0);
                    }
                })
            })
            .catch(error => {
                dialog.close();

                console.log(`An error occured: '${error.message}'`);
                process.exit(1);
            })
    });
})();

function getLongestPrefix(input) {
    return new Promise((resolve, reject) => {
        soap.createClient(config.wsdlUrl, (err, client) => {
            if (err) {
                reject(err);
            } else {
                client.GetLongestPalindromePrefix({
                   'input' : input
                }, (err, result) => {
                    if (err) {
                        reject(err);
                    } else {
                        resolve(result);
                    }
                });
            }
        })
    })
}


