const express = require('express');
const app = express();
const cors = require('cors');

app.use(express.json());
app.use(cors());

let patients = [
    {
        id: 'P001',
        name: 'John Doe',
        medicalHistory: ['Diabetes', 'Hypertension'],
        recommendations: [
            { name: 'Blood Sugar Test', completed: false },
            { name: 'Flu Shot', completed: false }
        ]
    },
    {
        id: 'P002',
        name: 'Jane Smith',
        medicalHistory: ['Allergy - Peanuts'],
        recommendations: [
            { name: 'Allergy Test', completed: false },
            { name: 'General Checkup', completed: false }
        ]
    }
];

app.get('/api/patients', (req, res) => {
    res.json(patients);
});

app.put('/api/patients/:id/recommendations', (req, res) => {
    const patient = patients.find(p => p.id === req.params.id);
    if (patient) {
        const recommendation = patient.recommendations.find(r => r.name === req.body.name);
        if (recommendation) {
            recommendation.completed = req.body.completed;
            res.json({ message: 'Updated successfully' });
        } else {
            res.status(404).json({ message: 'Recommendation not found' });
        }
    } else {
        res.status(404).json({ message: 'Patient not found' });
    }
});

app.listen(5000, () => console.log('Server running on port 5000'));
