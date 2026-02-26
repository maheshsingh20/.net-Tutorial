import { useEffect, useState } from 'react';

interface StudentData {
  id: number;
  name: string;
  age: number;
}

const Student = () => {
  const [students, setStudents] = useState<StudentData[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  useEffect(() => {
    const fetchStudents = async () => {
      try {
        const response = await fetch('https://localhost:7270/api/student');
        if (!response.ok) {
          throw new Error('Failed to fetch students');
        }
        const data = await response.json();
        setStudents(data);
      } catch (err) {
        setError(err instanceof Error ? err.message : 'An error occurred');
      } finally {
        setLoading(false);
      }
    };
    fetchStudents();
  }, []);
  if (loading) return <div>Loading...</div>;
  if (error) return <div>Error: {error}</div>;
  return (
    <div style={{ padding: '20px' }}>
      <h2>Student List</h2>
      <table style={{ width: '100%', borderCollapse: 'collapse' }}>
        <thead>
          <tr style={{ backgroundColor: '#f2f2f2' }}>
            <th style={{ border: '1px solid #ddd', padding: '8px' }}>ID</th>
            <th style={{ border: '1px solid #ddd', padding: '8px' }}>Name</th>
            <th style={{ border: '1px solid #ddd', padding: '8px' }}>Age</th>
          </tr>
        </thead>
        <tbody>
          {students.map((student) => (
            <tr key={student.id}>
              <td style={{ border: '1px solid #ddd', padding: '8px' }}>{student.id}</td>
              <td style={{ border: '1px solid #ddd', padding: '8px' }}>{student.name}</td>
              <td style={{ border: '1px solid #ddd', padding: '8px' }}>{student.age}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};
export default Student;
