import React, { useEffect, useState } from 'react';

// Type definition matching the shape of data from the API
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

    // Fetch bowler data from the backend when the component first loads
    useEffect(() => {
        fetch('http://localhost:5177/bowlers')
            .then((res) => res.json())
            .then((data) => setBowlers(data));
    }, []); // empty array = only run once on mount

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
                {/* Loop through each bowler and create a table row */}
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
