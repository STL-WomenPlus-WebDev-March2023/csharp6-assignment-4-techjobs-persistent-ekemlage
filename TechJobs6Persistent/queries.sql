-- Capture your answer here for each "Test It With SQL" section of this assignment
    -- write each as comments


--Part 1: List the columns and their data types in the Jobs table.

    -- Column Names: Id, Name, EmployerId
    -- Id data type: int
    -- Name data type: string
    -- EmployerId data type: int

--Part 2: Write a query to list the names of the employers in St. Louis City.

--SELECT Name
--FROM employers
--WHERE (Location = "St. Louis City");

--Part 3: Write a query to return a list of the names and descriptions of all skills that are attached to jobs in alphabetical order.
    --If a skill does not have a job listed, it should not be included in the results of this query.
    --SELECT SkillName
    --FROM skills
    --INNER JOIN jobskills ON skills.Id = JobSkills.SkillsId
    --WHERE SkillName IS NOT NULL
    --ORDER BY SkillName;

