# Use an official Node.js runtime as a base image
FROM node:24.11.1-alpine

# Set working directory
WORKDIR /usr/app

# Install PM2 globally
RUN npm install --global pm2

# Copy "package.json" and "package-lock.json" before other files
# Utilise Docker cache to save re-installing dependencies if unchanged
COPY ./package*.json ./

# Install dependencies
RUN npm install

# Change ownership to the non-root user
RUN chown -R node:node /usr/app
RUN chmod 777 .

# Copy all files
#COPY ./ ./
COPY --chown=node:node . .

# Build app
#RUN npm run build

# Expose the listening port
EXPOSE 3000

# Run container as non-root (unprivileged) user
# The "node" user is provided in the Node.js Alpine base image
USER node
RUN cd /usr/app
RUN chmod 777 .

# Launch app with PM2
CMD [ "pm2-runtime", "start", "npm", "--", "run", "dev" ]