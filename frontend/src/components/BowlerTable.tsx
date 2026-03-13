import React, { useEffect, useState } from 'react';

interface Bowler {
    name: string;
    team: string;
    bowlerAddress: string;
    bowlerCity: string;
    bowlerState: string;
    bowlerZip: string;
    bowlerPhoneNumber: string;
}

function BowlerTable() {
    const [bowlers, setBowlers] = useState<Bowler[]>([]);

    useEffect(() => {
        fetch('http://localhost:5177/bowlers')
            .then((res) => res.json())
            .then((data) => setBowlers(data));
    }, []);

    return (
        <table border={1} cellPadding={8}>
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Team</th>
                    <th>Address</th>
                    <th>City</th>
                    <th>State</th>
                    <th>Zip</th>
                    <th>Phone</th>
                </tr>
            </thead>
            <tbody>
                {bowlers.map((bowler, index) => (
                    <tr key={index}>
                        <td>{bowler.name}</td>
                        <td>{bowler.team}</td>
                        <td>{bowler.bowlerAddress}</td>
                        <td>{bowler.bowlerCity}</td>
                        <td>{bowler.bowlerState}</td>
                        <td>{bowler.bowlerZip}</td>
                        <td>{bowler.bowlerPhoneNumber}</td>
                    </tr>
                ))}
            </tbody>
        </table>
    );
}

export default BowlerTable;
