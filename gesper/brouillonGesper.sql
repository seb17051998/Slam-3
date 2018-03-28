select emp_id,emp_nom,emp_prenom, 
(select count(pos_diplome) from posseder) 
from employe









select count(pos_diplome) from posseder group by pos_employe;

SELECT emp_service
FROM employe
GROUP BY emp_service
HAVING COUNT(*) > 2

SELECT emp_id,emp_nom,emp_prenom,(select count(pos_diplome) from posseder)AND(select pos_diplome from posseder group by pos_employe) as NombreDiplome
FROM
    employe E
        INNER JOIN (
                SELECT emp_service
                FROM employe
                GROUP BY emp_service
                HAVING COUNT(*) > 2
            ) S
            ON E.emp_service = S.emp_service