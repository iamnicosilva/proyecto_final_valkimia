#!/bin/bash
read -p "Nombre del commit: " COMMIT
git add .
git commit -sm "$COMMIT"
git push origin trabajo-final
git push github
