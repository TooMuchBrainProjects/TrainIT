delete
from exercise_assets
where true;

delete
from machine_assets
where true;

delete
from muscle_assets
where true;

delete
from workout_assets
where true;

delete
from exercise_has_muscle_assets_jt
where true;

delete
from exercise_asset_has_muscle_assets_jt
where true;

delete
from workout_asset_has_exercise_assets_jt
where true;

insert into exercise_assets (EXERCISE_ASSET_ID, NAME, DESCRIPTION, MACHINE_ASSET_ID) 
VALUES (1, 'Battle Ropes', 'Hold onto two ropes and alternate whipping them up and down as fast as you can.', null),
       (2, 'Bench Press', 'Lie on a flat bench with a barbell in your hands, lower it down to your chest, then push it back up.', 2),
       (3, 'Deadlift', 'Stand with feet hip-width apart, bend forward to grab the barbell, and lift it up while keeping your back straight. Lower the barbell back down to the floor.', null),
       (4, 'Barbell Squats', 'Place a barbell across your shoulders and lower your hips down until your thighs are parallel to the floor. Push through your heels to stand back up.', 3),
       (5, 'Overhead Press', 'Stand with a barbell or dumbbells at shoulder height, then push them overhead until your arms are straight.', 3),
       (6, 'Pull-Ups', 'Grasp a pull-up bar with your palms facing away from your body and pull your chin up to the bar.', 4),
       (7, 'Rows', 'Hold a barbell in your hands and bend forward slightly, then pull the weight up towards your chest while keeping your elbows close to your body.', 3),
       (8, 'Lunges', 'Step forward with one foot and lower your body until your front thigh is parallel to the floor, then step back to the starting position and repeat on the other side.', null),
       (9, 'Leg Press', 'Sit on a leg press machine with your feet on the platform, then push the platform away from you with your legs.', 5),
       (10, 'Calf Raises', 'Stand with your toes on an elevated surface and raise your heels up as high as you can.', 6),
       (11, 'Bicep Curls', 'Hold a dumbbell in each hand with your palms facing up, then curl the weights up towards your shoulders.', null),
       (12, 'Tricep Extensions', 'Hold a dumbbell or barbell above your head with your arms straight, then bend your elbows to lower the weight behind your head.', null),
       (13, 'Dips', 'Sit on a dip station with your hands holding onto the edge, then lower your body down until your elbows are at a 90-degree angle, and push back up.', 7),
       (14, 'Crunches', 'Lie on your back with your knees bent and your hands behind your head, then lift your shoulders off the ground towards your knees.', null),
       (15, 'Plank', 'Get into a push-up position but hold your body straight like a plank, keeping your abs engaged.', null),
       (16, 'Russian Twists', 'Sit on the ground with your knees bent and your feet off the floor, then twist your torso from side to side while holding a weight.', null),
       (17, 'Mountain Climbers', 'Get into a push-up position and bring your knees up to your chest one at a time as fast as you can.', null),
       (18, 'Burpees', 'Start in a standing position, then squat down, jump back into a push-up position, do a push-up, jump back up to the squat position, and jump up in the air.', null),
       (19, 'Box Jumps', 'Stand in front of a box or platform, then jump up onto it and back down.', null),
       (20, 'Kettlebell Swings', 'Hold a kettlebell with both hands and swing it between your legs, then swing it up to shoulder height.', null),       
       (21, 'Incline Bench Press', 'Lie down on a bench at a 30-45 degree angle, grasp the barbell with hands slightly wider than shoulder-width apart, lower the barbell down to your chest, and push it back up until your arms are fully extended.', 8),
       (22, 'Shrugs', 'Hold a barbell or dumbbells at arm''s length by your sides, lift your shoulders up towards your ears as high as possible, hold for a second, and lower them back down.', null),       
       (23, 'Lat-Pulls', 'Sit at a lat-pull machine with your hands on the bar, pull the bar down towards your chest by engaging your back muscles, hold for a second, then release back up slowly.', 9),       
       (24, 'Leg Extensions', 'Sit on a leg extension machine, hook your feet under the padded bar, and straighten your legs until they are parallel to the ground, then release back down slowly.', 1);      

insert into machine_assets (MACHINE_ASSET_ID, NAME) 
VALUES (1, 'Leg extension machine'),
       (2, 'Chest press machine'),
       (3, 'Squat rack'),
       (4, 'Pull-up bar'),
       (5, 'Leg press machine'),
       (6, 'Calf raise machine'),
       (7, 'Dip station'),
       (8, 'Bench'),
       (9, 'Lat-pull machine');

       
