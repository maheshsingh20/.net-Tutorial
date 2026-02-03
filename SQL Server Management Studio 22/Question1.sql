use LPU_Db;
DELETE FROM Student s
WHERE NOT EXISTS (
    SELECT 1
    FROM Marks m
    WHERE m.StudentId = s.StudentId
);
